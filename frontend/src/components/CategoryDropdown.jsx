import React, { useEffect, useState } from "react";
import { NavDropdown } from "react-bootstrap";
import { Link } from "react-router-dom";
import axiosInstance from "../axiosInstance";

const CategoryDropdown = () => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    axiosInstance.get('api/category')
      .then(response => setCategories(response.data))
      .catch(error => console.error('Error fetching categories:', error));
  }, []);

  return (
    <NavDropdown title="محصولات" id="basic-nav-dropdown" className="nav-link-custom">
      <NavDropdown.Item as={Link} to="/">
        همه محصولات
      </NavDropdown.Item>
      <NavDropdown.Divider />
      {categories.map(category => (
        <NavDropdown.Item 
          key={category.id}
          as={Link} 
          to={`/product/category/${category.id}`}
        >
          {category.name}
        </NavDropdown.Item>
      ))}
    </NavDropdown>
  );
};

export default CategoryDropdown;

import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button } from "react-bootstrap";
import axiosInstance from "../axiosInstance";
import "../styles/ProductPage.css"; // Import the CSS file from the styles folder

const ProductPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (!id) {
      console.error("Invalid product id:", id);
      return;
    }

    console.log("Fetching product with id:", id);

    axiosInstance
      .get(`api/home/product/${id}`)
      .then((res) => {
        setProduct(res.data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching product:", err);
        setLoading(false);
      });
  }, [id]);

  if (loading) {
    return (
      <div className="container mt-4 px-3 mb-5 text-center">
        <div className="spinner"></div>
      </div>
    );
  }

  if (!product) {
    return (
      <div className="container mt-4 px-3 mb-5 text-center">
        <div className="alert">Product not found.</div>
      </div>
    );
  }

  return (
    <div className="container mt-4 px-3 mb-5">
      <div className="product-container">
        <img src={product.imageUrl} alt={product.name} className="product-image" />
        <h1 className="product-title">{product.name}</h1>
        <p className="product-description">{product.description}</p>
        <p className="product-price">${product.price}</p>
        <Button 
          variant="warning" 
          onClick={() => navigate(`/edit/product/${id}`)}
          className="mt-3"
        >
          ویرایش محصول
        </Button>
      </div>
    </div>
  );
};

export default ProductPage;

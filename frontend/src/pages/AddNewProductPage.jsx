import React, { useState } from "react";
import Container from "react-bootstrap/Container";
import axiosInstance from "../axiosInstance";
import { useNavigate } from "react-router-dom";
import ProductDetailsForm from "../components/ProductDetailsForm";

const AddNewProductPage = () => {
  const [validated, setValidated] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = (event) => {
    event.preventDefault();
    
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.stopPropagation();
      setValidated(true);
      return;
    }

    const formData = new FormData(form);
    const productData = {
      name: formData.get('name'),
      description: formData.get('description'),
      price: parseFloat(formData.get('price')),
      imageUrl: formData.get('imageUrl')
    };

    axiosInstance
      .post("api/product", productData)
      .then((response) => {
        navigate(`/product/${response.data}`);
      })
      .catch((error) => {
        console.error("Error adding product:", error);
      });
  };

  return (
    <Container className="mt-4 px-3 mb-5" dir="rtl">
      <h1 className="mb-5">افزودن محصول جدید</h1>
      <ProductDetailsForm onSubmit={handleSubmit} validated={validated} />
    </Container>
  );
};

export default AddNewProductPage;

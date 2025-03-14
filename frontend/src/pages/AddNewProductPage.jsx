import React, { useState } from "react";
import Container from "react-bootstrap/Container";
import axiosInstance from "../axiosInstance";
import { useNavigate } from "react-router-dom";
import ProductDetailsForm from "../components/ProductDetailsForm";

const AddNewProductPage = () => {
  const [validated, setValidated] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = (event) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      setValidated(true);
      return;
    }

    event.preventDefault();

    const formData = new FormData(form);
    axiosInstance
      .post("api/product", formData)
      .then((response) => {
        const productId = response.data;
        navigate(`/product/${productId}`);
      })
      .catch((error) => {
        console.error("Error adding product:", error);
        setValidated(true);
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

import React, { useState, useEffect } from "react";
import { Container, Alert, Spinner } from "react-bootstrap";
import { useParams, useNavigate } from "react-router-dom";
import axiosInstance from "../axiosInstance";
import ProductDetailsForm from "../components/ProductDetailsForm";

const EditProductPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [product, setProduct] = useState(null);
  const [validated, setValidated] = useState(false);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    axiosInstance.get(`api/product/${id}`)
      .then(response => {
        setProduct(response.data);
        setError(null);
      })
      .catch(error => {
        console.error("Error fetching product:", error);
        setError("Failed to load product");
      })
      .finally(() => setLoading(false));
  }, [id]);

  const handleSubmit = (event) => {
    event.preventDefault();
    const form = event.currentTarget;
    
    if (!form.checkValidity()) {
      event.stopPropagation();
      setValidated(true);
      return;
    }

    const formData = new FormData(form);
    const updateData = {
      id: parseInt(id),
      name: formData.get('name'),
      description: formData.get('description') || "",
      price: formData.get('price') ? parseFloat(formData.get('price')) : 0,
      imageUrl: formData.get('imageUrl') || ""
    };

    axiosInstance.put('api/product', updateData, {
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(() => {
        console.log("Product updated successfully");
        navigate(`/product/${id}`);
      })
      .catch(error => {
        console.error("Error updating product:", error.response?.data || error.message);
        setError(error.response?.data || "Failed to update product");
      });
  };

  if (loading) {
    return (
      <Container className="d-flex justify-content-center mt-4">
        <Spinner animation="border" />
      </Container>
    );
  }

  if (error) {
    return (
      <Container className="mt-4">
        <Alert variant="danger">{error}</Alert>
      </Container>
    );
  }

  return (
    <Container className="mt-4 px-3 mb-5" dir="rtl">
      <h1 className="mb-5">ویرایش محصول</h1>
      <ProductDetailsForm 
        onSubmit={handleSubmit}
        product={product}
        validated={validated}
      />
    </Container>
  );
};

export default EditProductPage;

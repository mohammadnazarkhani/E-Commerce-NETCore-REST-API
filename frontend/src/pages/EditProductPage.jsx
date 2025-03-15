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

  const handleSubmit = async (event) => {
    event.preventDefault();
    const form = event.currentTarget;
    
    if (!form.checkValidity()) {
      event.stopPropagation();
      setValidated(true);
      return;
    }

    const formData = new FormData(form);
    const imageUrl = formData.get('imageUrl');
    
    // Validate URL if provided
    if (imageUrl && !imageUrl.match(/^https?:\/\/.+/)) {
      setError('Please enter a valid http:// or https:// URL for the image');
      return;
    }

    const updateData = {
      id: parseInt(id),
      name: formData.get('name'),
      description: formData.get('description') || "",
      price: formData.get('price') ? parseFloat(formData.get('price')) : 0,
      imageUrl: imageUrl || null
    };

    try {
      await axiosInstance.put('api/product', updateData);
      navigate(`/product/${id}`);
    } catch (error) {
      const errorMessage = error.response?.data?.errors
        ? Object.values(error.response.data.errors).flat().join(', ')
        : 'Error updating product';
      setError(errorMessage);
    }
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

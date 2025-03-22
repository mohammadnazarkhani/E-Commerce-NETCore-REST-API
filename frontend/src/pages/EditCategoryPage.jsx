import React, { useState, useEffect } from "react";
import { Container, Alert, Spinner } from "react-bootstrap";
import { useParams, useNavigate } from "react-router-dom";
import axiosInstance from "../axiosInstance";
import CategoryDetailsForm from "../components/CategoryDetailsForm";

const EditCategoryPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [category, setCategory] = useState(null);
  const [validated, setValidated] = useState(false);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    axiosInstance
      .get(`api/category/${id}`)
      .then((response) => {
        setCategory(response.data);
        setError(null);
      })
      .catch((error) => {
        console.error("Error fetching category:", error);
        setError("Failed to load category");
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
    const updateData = {
      id: parseInt(id),
      name: formData.get("name"),
    };

    try {
      await axiosInstance.put(`api/category/${id}`, updateData);
      navigate("/categories");
    } catch (error) {
      setError(error.response?.data?.message || "Error updating category");
    }
  };

  if (loading) {
    return (
      <Container className="d-flex justify-content-center mt-4">
        <Spinner animation="border" />
      </Container>
    );
  }

  return (
    <Container className="mt-4 px-3 mb-5" dir="rtl">
      <h1 className="mb-4">ویرایش دسته‌بندی</h1>
      {error && <Alert variant="danger">{error}</Alert>}
      <CategoryDetailsForm
        onSubmit={handleSubmit}
        category={category}
        validated={validated}
      />
    </Container>
  );
};

export default EditCategoryPage;

import React, { useState } from "react";
import { Container, Alert } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import axiosInstance from "../axiosInstance";
import CategoryDetailsForm from "../components/CategoryDetailsForm";

const AddNewCategoryPage = () => {
  const navigate = useNavigate();
  const [validated, setValidated] = useState(false);
  const [error, setError] = useState(null);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const form = event.currentTarget;

    if (!form.checkValidity()) {
      event.stopPropagation();
      setValidated(true);
      return;
    }

    const formData = new FormData(form);
    const categoryData = {
      name: formData.get("name"),
    };

    try {
      await axiosInstance.post("api/category", categoryData);
      navigate("/categories");
    } catch (error) {
      setError(error.response?.data?.message || "خطا در ایجاد دسته‌بندی");
    }
  };

  return (
    <Container className="mt-4 px-3 mb-5" dir="rtl">
      <h1 className="mb-4">افزودن دسته‌بندی جدید</h1>
      {error && <Alert variant="danger">{error}</Alert>}
      <CategoryDetailsForm onSubmit={handleSubmit} validated={validated} />
    </Container>
  );
};

export default AddNewCategoryPage;

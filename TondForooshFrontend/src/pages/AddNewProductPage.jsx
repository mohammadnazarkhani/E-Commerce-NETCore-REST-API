import React, { useState } from "react";
import { Button } from "react-bootstrap";
import Container from "react-bootstrap/Container";
import Form from "react-bootstrap/Form";
import axiosInstance from "../axiosInstance";
import { useNavigate } from "react-router-dom";

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
      <Form noValidate validated={validated} onSubmit={handleSubmit}>
        <Form.Group className="mb-3 " controlId="formProductName">
          <Form.Label>نام محصول</Form.Label>
          <Form.Control type="text" name="name" required isInvalid />
          <Form.Control.Feedback type="invalid">
            برای محصولتان نامی انتخاب کنید.
          </Form.Control.Feedback>
        </Form.Group>
        <Form.Group className="mb-3" controlId="formProductDescription">
          <Form.Label>توضیحات محصول</Form.Label>
          <Form.Control as="textarea" name="description" rows={3} />
        </Form.Group>
        <Form.Group className="mb-3" controlId="formProductPrice">
          <Form.Label>قیمت محصول</Form.Label>
          <Form.Control type="number" name="price" required isInvalid />
          <Form.Control.Feedback type="invalid">
            قیمت محصولتان را تعیین نمایید.
          </Form.Control.Feedback>
        </Form.Group>
        <Form.Group className="mb-3" controlId="formProductImageUrl">
          <Form.Label>آدرس آنلاین تصویر محصول</Form.Label>
          <Form.Control type="text" name="imageUrl" />
        </Form.Group>
        <Form.Group>
          <Button type="submit">افزودن محصول</Button>
        </Form.Group>
      </Form>
    </Container>
  );
};

export default AddNewProductPage;

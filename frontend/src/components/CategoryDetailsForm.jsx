import React from "react";
import { Button, Form } from "react-bootstrap";

const CategoryDetailsForm = ({ onSubmit, category, validated }) => {
  return (
    <Form noValidate validated={validated} onSubmit={onSubmit}>
      <Form.Group className="mb-3" controlId="formCategoryName">
        <Form.Label>نام دسته‌بندی</Form.Label>
        <Form.Control
          type="text"
          name="name"
          required
          defaultValue={category?.name || ''}
        />
        <Form.Control.Feedback type="invalid">
          برای دسته‌بندی نامی انتخاب کنید.
        </Form.Control.Feedback>
      </Form.Group>

      <Form.Group>
        <Button type="submit">
          {category ? 'ویرایش دسته‌بندی' : 'افزودن دسته‌بندی'}
        </Button>
      </Form.Group>
    </Form>
  );
};

export default CategoryDetailsForm;

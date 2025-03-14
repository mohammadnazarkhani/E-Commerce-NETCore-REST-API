import React from "react";
import { Button, Form } from "react-bootstrap";

const ProductDetailsForm = ({ onSubmit, product, validated }) => {
  return (
    <Form noValidate validated={validated} onSubmit={onSubmit}>
      <Form.Group className="mb-3" controlId="formProductName">
        <Form.Label>نام محصول</Form.Label>
        <Form.Control
          type="text"
          name="name"
          required
          defaultValue={product?.name || ''}
        />
        <Form.Control.Feedback type="invalid">
          برای محصولتان نامی انتخاب کنید.
        </Form.Control.Feedback>
      </Form.Group>
      <Form.Group className="mb-3" controlId="formProductDescription">
        <Form.Label>توضیحات محصول</Form.Label>
        <Form.Control
          as="textarea"
          name="description"
          rows={3}
          defaultValue={product?.description || ''}
        />
      </Form.Group>
      <Form.Group className="mb-3" controlId="formProductPrice">
        <Form.Label>قیمت محصول</Form.Label>
        <Form.Control
          type="number"
          name="price"
          required
          defaultValue={product?.price || ''}
        />
        <Form.Control.Feedback type="invalid">
          قیمت محصولتان را تعیین نمایید.
        </Form.Control.Feedback>
      </Form.Group>
      <Form.Group className="mb-3" controlId="formProductImageUrl">
        <Form.Label>آدرس آنلاین تصویر محصول</Form.Label>
        <Form.Control
          type="text"
          name="imageUrl"
          defaultValue={product?.imageUrl || ''}
        />
      </Form.Group>
      <Form.Group>
        <Button type="submit">
          {product ? 'ویرایش محصول' : 'افزودن محصول'}
        </Button>
      </Form.Group>
    </Form>
  );
};

export default ProductDetailsForm;

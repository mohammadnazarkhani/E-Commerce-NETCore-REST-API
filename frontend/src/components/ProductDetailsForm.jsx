import React, { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import axiosInstance from "../axiosInstance";

const ProductDetailsForm = ({ onSubmit, product, validated }) => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    axiosInstance.get('api/category')
      .then(response => setCategories(response.data))
      .catch(error => console.error('Error fetching categories:', error));
  }, []);

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
          type="url"
          name="imageUrl"
          pattern="https?://.+"
          placeholder="https://example.com/image.jpg"
          defaultValue={product?.imageUrl || ''}
        />
        <Form.Text className="text-muted">
          لطفا یک آدرس معتبر http یا https وارد کنید
        </Form.Text>
        <Form.Control.Feedback type="invalid">
          لطفا یک آدرس معتبر وارد کنید (مثال: https://example.com/image.jpg)
        </Form.Control.Feedback>
      </Form.Group>
      
      <Form.Group className="mb-3" controlId="formProductCategory">
        <Form.Label>دسته‌بندی محصول</Form.Label>
        <Form.Select 
          name="categoryId"
          required
          value={product?.categoryId || ''}
          onChange={(e) => e.currentTarget.value}
        >
          <option value="">انتخاب دسته‌بندی</option>
          {categories.map(category => (
            <option key={category.id} value={category.id}>
              {category.name}
            </option>
          ))}
        </Form.Select>
        <Form.Control.Feedback type="invalid">
          لطفاً یک دسته‌بندی انتخاب کنید.
        </Form.Control.Feedback>
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

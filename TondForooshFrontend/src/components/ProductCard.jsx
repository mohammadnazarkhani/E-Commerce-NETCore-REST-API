import React from "react"; 
import { Card, Button } from "react-bootstrap";

const ProductCard = ({ product }) => (
  <Card className="product-card d-flex h-100"> {/* Ensure equal height */}
    <Card.Img variant="top" src={product.imageUrl} alt={product.name} />
    <Card.Body>
      <Card.Title>{product.name}</Card.Title>
      <Card.Text>{product.description}</Card.Text>
      <Button variant="warning">Buy - ${product.price}</Button>
    </Card.Body>
  </Card>
);

export default ProductCard;

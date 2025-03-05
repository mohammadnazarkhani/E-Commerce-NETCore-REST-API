import { useEffect, useState } from 'react';
import { Container, Row, Col, Card, Button, Navbar, Nav } from 'react-bootstrap';
import './styles.css'; // if you are using custom CSS for orange theme

function App() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    // Fetch products from your backend API (you can use a mock API or local server)
    fetch('http://localhost:5000/api/home/products')
      .then((response) => response.json())
      .then((data) => setProducts(data));
  }, []);

  return (
    <div>
      {/* Navbar */}
      <Navbar bg="primary" variant="dark">
        <Container>
          <Navbar.Brand href="#">TondForoosh</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link href="#home">Home</Nav.Link>
            <Nav.Link href="#products">Products</Nav.Link>
          </Nav>
        </Container>
      </Navbar>

      {/* Products Section */}
      <Container className="mt-4">
        <Row>
          {products.map((product) => (
            <Col key={product.id} md={4}>
              <Card>
                <Card.Img variant="top" src={product.imageUrl} />
                <Card.Body>
                  <Card.Title>{product.name}</Card.Title>
                  <Card.Text>{product.description}</Card.Text>
                  <Button variant="primary">${product.price}</Button>
                </Card.Body>
              </Card>
            </Col>
          ))}
        </Row>
      </Container>
    </div>
  );
}

export default App;

package sep3.warehouse.services.productService;

import org.springframework.stereotype.Service;
import sep3.warehouse.models.Product;

import java.util.List;
import java.util.Optional;

@Service
public class ProductServiceImplementation {

    private ProductService productService;

    public ProductServiceImplementation(ProductService productService) {
        this.productService = productService;
    }

    public List<Product> getAllProducts() {
        return productService.findAll();
    }

    public Optional<Product> getProductById(Long id) {
        return productService.findById(id);
    }

}

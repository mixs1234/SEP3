package sep3.warehouse;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import sep3.warehouse.DTO.brands.BrandDTO;
import sep3.warehouse.DTO.products.CreateProductDto;
import sep3.warehouse.DTO.products.ProductDTO;
import sep3.warehouse.entities.Brand;
import sep3.warehouse.entities.Product;


import jakarta.persistence.EntityNotFoundException;
import sep3.warehouse.service.ProductRepo;
import sep3.warehouse.service.ProductService;

import java.util.List;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
class ProductServiceTest {

    @Mock
    private ProductRepo productRepo;

    @InjectMocks
    private ProductService productService;

    @Test
    void testFindById_Success() {

        Brand brand = new Brand(1L, "Nike", null);


        Product product = new Product();
        product.setId(1L);
        product.setName("Nike T-Shirt");
        product.setDescription("A comfortable t-shirt");
        product.setPrice(99.99);
        product.setImagePath("/images/nike-tshirt.jpg");
        product.setBrand(brand);


        when(productRepo.findById(1L)).thenReturn(Optional.of(product));


        ProductDTO result = productService.findById(1L);


        assertNotNull(result);
        assertEquals("Nike T-Shirt", result.getName());
        assertEquals("A comfortable t-shirt", result.getDescription());
        assertEquals(99.99, result.getPrice());
        assertEquals("/images/nike-tshirt.jpg", result.getImagePath());
        assertEquals("Nike", result.getBrand().getName());


        verify(productRepo, times(1)).findById(1L);
    }


    @Test
    void testFindById_NotFound() {

        when(productRepo.findById(1L)).thenReturn(Optional.empty());


        EntityNotFoundException exception = assertThrows(EntityNotFoundException.class, () -> productService.findById(1L));
        assertEquals("product with 1 not found", exception.getMessage());
        verify(productRepo, times(1)).findById(1L);
    }

    @Test
    void testFindAll() {

        Brand brand = new Brand(1L, "Nike", null);


        Product product1 = new Product();
        product1.setId(1L);
        product1.setName("Nike T-Shirt");
        product1.setDescription("A comfortable t-shirt");
        product1.setPrice(99.99);
        product1.setImagePath("/images/nike-tshirt.jpg");
        product1.setBrand(brand);

        Product product2 = new Product();
        product2.setId(2L);
        product2.setName("Adidas Shorts");
        product2.setDescription("Comfortable shorts");
        product2.setPrice(79.99);
        product2.setImagePath("/images/adidas-shorts.jpg");
        product2.setBrand(brand);


        when(productRepo.findAll()).thenReturn(List.of(product1, product2));


        List<ProductDTO> result = productService.findAll();


        assertEquals(2, result.size());
        assertEquals("Nike T-Shirt", result.get(0).getName());
        assertEquals("Adidas Shorts", result.get(1).getName());


        verify(productRepo, times(1)).findAll();
    }

    @Test
    void testCreateProduct_NoBrand() {
        // Opret CreateProductDto uden brand, men sæt brand til en ID-værdi (f.eks. 1)
        CreateProductDto createProductDto = new CreateProductDto();
        createProductDto.setName("Nike T-Shirt");
        createProductDto.setDescription("A comfortable t-shirt");
        createProductDto.setPrice(99.99);
        createProductDto.setImagePath("/images/nike-tshirt.jpg");
        createProductDto.setBrand(new BrandDTO("Nike", 1L)); // Sæt brand til at være et BrandDTO med id 1


        Product product = CreateProductDto.mapCreateProductDtoToProduct(createProductDto);


        when(productRepo.save(any(Product.class))).thenReturn(product);


        ProductDTO result = productService.createProduct(createProductDto);


        assertNotNull(result);
        assertEquals("Nike T-Shirt", result.getName());
        assertEquals("A comfortable t-shirt", result.getDescription());
        assertEquals(99.99, result.getPrice());
        assertEquals("/images/nike-tshirt.jpg", result.getImagePath());
        assertNotNull(result.getBrand());


        verify(productRepo, times(1)).save(any(Product.class));
    }


    @Test
    void testCreateProduct_NullDto() {

        IllegalArgumentException exception = assertThrows(IllegalArgumentException.class, () -> productService.createProduct(null));
        assertEquals("createProductDto cannot be null", exception.getMessage());
        verify(productRepo, never()).save(any());
    }
}

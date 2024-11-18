package sep3.warehouse.entities;


import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import jakarta.persistence.*;
import lombok.*;

import java.util.List;


@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@Entity
@Table(name = "product")
public class Product {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, length = 255)
    private String name;

    @Column(nullable = false, length = 255)
    private String description;

    @Column(nullable = false)
    private double price;

    @Column(nullable = false)
    private String imagePath;

    @ManyToOne
    @JoinColumn(name = "brand_id")
    @JsonIgnoreProperties("products")
    private Brand brand;

    @JsonIgnoreProperties
    @OneToMany(mappedBy = "product", fetch = FetchType.LAZY)
    private List<ProductVariant> productVariants;
}

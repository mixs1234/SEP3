package sep3.warehouse.service;


import lombok.RequiredArgsConstructor;

import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.BrandDTO;
import sep3.warehouse.entities.Brand;

import java.util.Optional;

@Service
@RequiredArgsConstructor
public class BrandService {
    private final IBrandService brandService;

    public Optional<Brand> findById(BrandDTO brandDTO) {
        Long brandId = brandDTO.getId();

        return brandService.findById(brandId);
    }


}

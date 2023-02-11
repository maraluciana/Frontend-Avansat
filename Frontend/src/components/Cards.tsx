import { Box } from "@mui/material";
import { GetProducts } from "../context/products";
import ProductCard from "./ProductCard";

const Cards: React.FC = () => {
    const products = GetProducts();
    return (
        <Box sx={{ display: 'flex', flexDirection: 'row',justifyContent: 'space-between', flexWrap: 'wrap' }}>
            {products.map(prod => 
                <ProductCard name = {prod.name} path = {prod.path} price = {prod.price} id = {prod.id} productType = {prod.productType}/>  
            )}
        </Box>

    );

}

export default Cards;
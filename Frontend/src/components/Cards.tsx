import { Box } from "@mui/material";
import { GetProducts, GetProductsByType } from "../context/products";
import ProductCard from "./ProductCard";



const styleCards =  {
    display: 'flex', 
    flexDirection: 'row',
    justifyContent: 'space-evenly',
    flexWrap: 'wrap',
    };


const Cards: React.FC = () => {
    const products = GetProducts();
    return (
        <Box sx={styleCards}>
            {products.map(prod => 
                <ProductCard name = {prod.name} path = {prod.path} price = {prod.price} id = {prod.id} productType = {prod.productType}/>  
            )}
        </Box>

    );

}

export const CardsFlowers : React.FC = () => {
    const products = GetProductsByType("flower");
    return (
        <Box sx={styleCards}>
            {products.map(prod => 
                <ProductCard name = {prod.name} path = {prod.path} price = {prod.price} id = {prod.id} productType = {prod.productType}/>  
            )}
        </Box>

    );

}

export const CardsBonsai : React.FC = () => {
    const products = GetProductsByType("bonsai");
    return (
        <Box sx={styleCards}>
            {products.map(prod => 
                <ProductCard name = {prod.name} path = {prod.path} price = {prod.price} id = {prod.id} productType = {prod.productType}/>  
            )}
        </Box>

    );

}

export default Cards;
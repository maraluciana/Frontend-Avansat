import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { Box, CardActionArea } from '@mui/material';
import { Product } from '../context/products';

const ProductCard: React.FC<Product> = ({ name, path , price, productType, id}) => { 
  return (
    <Box>
        <Card sx={{ margin: '15px', maxWidth: 345}}>
        <CardActionArea>
            <CardMedia
            component="img"
            height="250"
            image={path}
            alt="product"
            />
            <CardContent>
            <Typography gutterBottom variant="h5" component="div">
                {name}
            </Typography>
            <Typography variant="body2" color="text.secondary">
                {price} LEI
            </Typography>
            </CardContent>
        </CardActionArea>
        </Card>
    </Box>
  );
}

export default ProductCard;
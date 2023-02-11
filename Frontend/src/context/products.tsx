import { useState, useEffect } from 'react';


export interface Product {
   id: number;
   productType: string;
   name: string;
   path: string;
   price: number;
}


const Products: React.FC = () => {
   const [products, setProducts] = useState<Product[]>([]);


   useEffect(() => {
      fetch("https://localhost:44362/api/Product/Get_All_Products")
         .then((res) => res.json())
         .then((data) => {
            console.log(data);
            setProducts(data);
         })
         .catch((err) => {
            console.log(err.message);
         });
   }, []);

   return (
      <ul>
         {products.map(({ id, name }) => (
            <li key={id}>
               {name}
            </li>
         ))}
      </ul>
   );
};


const GetProducts = () => {
   const [products, setProducts] = useState<Product[]>([]);

   useEffect(() => {
      fetch("https://localhost:44362/api/Product/Get_All_Products")
         .then((res) => res.json())
         .then((data) => {
            console.log(data);
            setProducts(data);
         })
         .catch((err) => {
            console.log(err.message);
         });
   }, []);

   return products
};

export default Products;
export { GetProducts };
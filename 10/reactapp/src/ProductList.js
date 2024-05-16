import React, {useState,useEffect} from 'react';
import axios from 'axios';

const ProductList = () => {
    const [products, setProducts] = useState([]);
    const [filter, setFilter] = useState('');

    useEffect(() => {
        axios.get('https://dummyjson.com/products')
          .then(response => {
            const products = response.data.products;
            setProducts(products);
          })
          .catch(error => console.error("There was an error!", error));
      }, []);

    return (
        <div> 
            <h1>List of products</h1>
            <label>Filter by product title:</label>
            <input type="text" value={filter} onChange={e => setFilter(e.target.value)} />  
            <ul>
                {products.filter(product => product.title.toLowerCase().includes(filter.toLowerCase())).map(product => ( <ProductItem key={product.id} title={product.title} brand={product.brand} /> ))}
            </ul>
        </div>
    );
};

function ProductItem({title, brand }) {
    return <li>{title} ({brand})</li>;
  }

export default ProductList;
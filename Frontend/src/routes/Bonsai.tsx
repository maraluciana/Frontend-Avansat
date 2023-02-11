import { Box } from "@mui/material";
import ListHeader from "../components/ListHeader";
import ToDoItem from "../components/ToDoItem";
import { useTodoActions, useTodoData } from '../context';
import Products from "../context/products";

const style = {
    display: 'flex',
    alignItems: 'center',
    flexDirection: 'column'
}

const Bonsais: React.FC = () => {

    return (
        <Box sx={style}>
            <br></br>
            <div>
                <Products />
            </div>
        </Box>
    );
}

export default Bonsais;
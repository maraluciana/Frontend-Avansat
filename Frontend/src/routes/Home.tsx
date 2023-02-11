import { Box } from "@mui/material";
import Cards from "../components/Cards";
import ListHeader from "../components/ListHeader";
import ToDoItem from "../components/ToDoItem";
import { useTodoActions, useTodoData } from '../context';
import Products from "../context/products";

const style = {
    display: 'flex',
    flexDirection: 'column'
}

const Home: React.FC = () => {

    return (
        <Box>
            <br></br>
            <Box >
                <Cards />
            </Box>
        </Box>
    );
}

export default Home;
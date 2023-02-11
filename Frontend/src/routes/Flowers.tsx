import { Box } from "@mui/material";
import { CardsFlowers } from "../components/Cards";

import { useTodoActions, useTodoData } from '../context';


const Flowers: React.FC = () => {
    const items = useTodoData()
    const { editTodo } = useTodoActions()

    return (
        <Box>
            <br></br>
            <CardsFlowers/>
        </Box>
    );
}

export default Flowers;
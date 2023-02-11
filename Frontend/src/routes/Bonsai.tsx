import { Box } from "@mui/material";
import ListHeader from "../components/ListHeader";
import ToDoItem from "../components/ToDoItem";
import { useTodoActions, useTodoData } from '../context';

const style = {
    display: 'flex',
    alignItems: 'center',
    flexDirection: 'column'
}

const Bonsais: React.FC = () => {
    const items = useTodoData()
    const { editTodo } = useTodoActions()

    return (
        <Box sx={style}>
            <br></br>
            <ListHeader />
            {
                items.map((item, index) => <ToDoItem key={index} item={item} onAction={
                    () => {
                        editTodo(index, item.status)
                    }
                } />)
            }
        </Box>
    );
}

export default Bonsais;
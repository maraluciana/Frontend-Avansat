import { TextField, Box, Button } from "@mui/material"
import React, { useState, useMemo, useCallback } from "react"
import { useTodoActions } from "../context";


const ListHeader: React.FC = () => {
    const [text, setText] = useState('');

    const { addTodo } = useTodoActions()

    const handleChange = useCallback((event: React.ChangeEvent<HTMLInputElement>) => {
        setText(event.target.value)
    }, []);

    const handleCreate = useCallback(() => {
        addTodo(text)
        setText('')
    }, [text, addTodo]);

    const style = useMemo(() => {
        return {
            display: 'flex',
            flexDirection: 'row',
            gap: '10px',
            width: '500px'
        }
    }, []);

    return (
        <Box sx={style} >
            <TextField
                fullWidth
                label="ToDo"
                variant="outlined"
                value={text}
                onChange={handleChange}
            />
            <Button variant="contained" onClick={handleCreate}>Create</Button>
        </Box>
    )
}

export default ListHeader
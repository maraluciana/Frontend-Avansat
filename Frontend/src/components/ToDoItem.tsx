import { Box, Button, Typography } from "@mui/material"
import React, { useMemo } from "react"
import { ListItem, ListItemStatus } from "../types"

export interface TodoItemProps {
    item: ListItem
    onAction?: () => void
}

const ToDoItem: React.FC<TodoItemProps> = ({ item, onAction }) => {
    const btnText = useMemo(() => {
        switch (item.status) {
            case ListItemStatus.todo: {
                return 'Start'
            }
            case ListItemStatus.active: {
                return 'Close'
            }
            case ListItemStatus.closed: {
                return 'Open'
            }
        }
    }, [item.status])

    return (
        <Box>
            <Typography variant="subtitle1" component="span">
                {item.text}
            </Typography>
            <Button onClick={onAction}>{btnText}</Button>
        </Box>
    )
}

export default ToDoItem
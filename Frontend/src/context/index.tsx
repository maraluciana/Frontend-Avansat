import React, { createContext, useCallback, useContext, useMemo, useState } from "react";
import { ListItem, ListItemStatus } from "../types";

interface StateCtxInterface {
    state: ListItem[];
    actions: {
        addTodo: (data: string) => void;
        editTodo: (index: number, currentStatus: ListItemStatus) => void
    };
}

const StateCtx = createContext<StateCtxInterface>({
    state: [],
    actions: {
        addTodo: () => { },
        editTodo: () => { }
    }
})

const StateProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [state, setState] = useState<ListItem[]>([])

    const addTodo = useCallback((text: string) => {
        setState([
            ...state,
            { status: ListItemStatus.todo, text }
        ])
    }, [state]);

    const editTodo = useCallback((index: number, currentStatus: ListItemStatus) => {
        let newStatatus = ListItemStatus.todo;
        if (currentStatus === ListItemStatus.todo) {
            newStatatus = ListItemStatus.active
        }
        if (currentStatus === ListItemStatus.active) {
            newStatatus = ListItemStatus.closed
        }
        const newState = [...state]
        newState[index].status = newStatatus
        setState(newState);
    }, [state]);

    const ctxValue: StateCtxInterface = useMemo(() => ({
        state,
        actions: {
            addTodo,
            editTodo
        }
    }), [state, addTodo, editTodo])

    return <StateCtx.Provider value={ctxValue}>{children}</StateCtx.Provider>
}

export const useTodoData = () => {
    const { state } = useContext(StateCtx);
    return state;
}

export const useTodoActions = () => {
    const { actions } = useContext(StateCtx)
    return actions
}

export default StateProvider

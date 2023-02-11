export const enum ListItemStatus {
    todo = 'todo',
    active = 'active',
    closed = 'closed'
}

export interface ListItem {
    text: string;
    status: ListItemStatus
}
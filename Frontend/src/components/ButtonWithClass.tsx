import React from "react";

interface ButtonProps {
    onClick?: () => void;
    children?: React.ReactNode
}

class ButtonWithClass extends React.Component<ButtonProps> {
    render(): React.ReactNode {
        return <button onClick={this.props.onClick}>{this.props.children}</button>
    }
}

export default ButtonWithClass
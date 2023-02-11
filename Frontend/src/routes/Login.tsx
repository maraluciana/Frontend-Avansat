import { Box } from "@mui/material";
import LoginForm from "../components/LoginForm";

const style = {
    display: 'flex',
    alignItems: 'center',
    flexDirection: 'column'
}

const Login: React.FC = () => {

    return (
        <Box sx={style}>
            <LoginForm/>
        </Box>
        
    );
}

export default Login;
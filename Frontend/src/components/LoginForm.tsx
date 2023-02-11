import { Paper } from '@mui/material';
import { Box } from '@mui/system';
import React, { useState } from 'react';

const LoginForm: React.FC = () => {
    const [name, setName] = useState<string>('');
    const [password, setPassword] = useState<string>('');

    const handleNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    }

    const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
    }


    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        alert(`${name}, you successfully logged in!`);
        event.preventDefault();
    }

    const styleContainer = {
        display: 'flex',
        alignItems: 'center',
        height: '100vh'
      };

    const stylePaper = { 
        width: '300px',
        height: '300px',
        padding: '20px',
        margin: 'auto',
        background : 'gray', 
    };

    const styleForm = {
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        height: "100%",
        width: "100%"
    };
    

    return (
        <Box style={styleContainer}>
        <Paper elevation={3} style = {stylePaper}>
            <Box style={styleForm}>
                <form  onSubmit={handleSubmit} >
                <label >
                    Name:
                    <input type="name" value={name} onChange={handleNameChange} style = {{margin : '10px'}}/>
                </label>
                <br />
                <label>
                    Password:
                    <input type="password" value={password} onChange={handlePasswordChange} style = {{margin : '10px'}}/>
                </label>
                <br />
                <input type="submit" value="Submit" />
                </form>
            </Box>
        </Paper>
        </Box>
    );
}

export default LoginForm;
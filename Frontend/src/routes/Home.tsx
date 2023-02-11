import { Box } from "@mui/material";
import Cards from "../components/Cards";

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
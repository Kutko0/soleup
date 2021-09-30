import Card from '@material-ui/core/Card'
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import { CardActionArea, CardMedia } from '@material-ui/core';
import { Paper, TextField } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
    root: {
      width: 280,
      border: "none",
      boxShadow: "none"
    },
    title: {
      fontSize: 11.7,

    },
    media: {
      height: "250px",
    },

}));
let MarketplaceItem = (props) => {
    const classes = useStyles()
    return(
        <div>
            <Paper>
                <CardMedia>
                    
                </CardMedia>
            </Paper>
        </div>
    )
}

export default MarketplaceItem;
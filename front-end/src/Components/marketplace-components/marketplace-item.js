import Card from '@material-ui/core/Card'
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import { CardActionArea, CardActions, CardMedia } from '@material-ui/core';
import Button from '@material-ui/core/Button';

const useStyles = makeStyles((theme) => ({
    root: {
      width: 270,
      height: 360,
      border: "outset",
      borderWidth: "1px",
      boxShadow: "none"
    },
    title: {
      fontSize: 11.7,

    },
    media: {
      height: "250px",
    },
    button: {
      justifyContent: "right"
    }


}));
let MarketplaceItem = (props) => {
    const classes = useStyles()
    return(

        <Card className={classes.root}>
          
            <CardContent>
                <CardMedia
                  className={classes.media}
                  title={props.title}
                  image={props.image}
                >
                </CardMedia>
                <Typography className={classes.title} color="textSecondary">
                    {props.name}
                </Typography>
                <Typography variant="h7" gutterBottom style={{textAlign: "left"}}>
                    {props.price}
                </Typography>
                <CardActions className={classes.button}>
                  <Button size="medium" > PURCHASE</Button>
                </CardActions>
            </CardContent>
        </Card>
    )
}

export default MarketplaceItem;
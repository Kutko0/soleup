import Card from '@material-ui/core/Card'
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import { CardActionArea, CardMedia } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
    root: {
      width: 280
    },
    title: {
      fontSize: 14,
    },
    media: {
      height: "250px",
    },

}));
let MarketplaceItem = function(){
    const classes = useStyles()
    return(
        <Card className={classes.root}>
          <CardActionArea>
            <CardContent>
                <CardMedia
                  className={classes.media}
                  title="props.mediaName"
                  image="https://storage.googleapis.com/bit-docs/bit-logo%402x.png"
                >
                </CardMedia>
                <Typography variant="h5" component="h2">
                    Product name
                </Typography>
                <Typography className={classes.title} color="textSecondary" gutterBottom>
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry
                </Typography>
            </CardContent>
          </CardActionArea>
        </Card>
    )
}

export default MarketplaceItem;
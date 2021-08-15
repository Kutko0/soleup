import Card from '@material-ui/core/Card'
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import { CardActionArea, CardMedia } from '@material-ui/core';

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
let MarketplaceItem = function(){
    const classes = useStyles()
    return(
        <Card className={classes.root}>
          <CardActionArea>
            <CardContent>
                <CardMedia
                  className={classes.media}
                  title="props.mediaName"
                  image="https://nl.kicksmaniac.com/zdjecia/2020/11/01/511/03/NIKE_AIR_JORDAN_4_RETRO_METALLIC_RED-mini.jpg"
                >
                </CardMedia>
                <Typography className={classes.title} color="textSecondary">
                    NIKE AIR JORDAN 4 RETRO METALLIC RED
                </Typography>
                <Typography variant="h6" gutterBottom style={{textAlign: "center"}}>
                    250€
                </Typography>
            </CardContent>
          </CardActionArea>
        </Card>
    )
}

export default MarketplaceItem;
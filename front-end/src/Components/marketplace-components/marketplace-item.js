import Card from '@material-ui/core/Card'
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import { CardActions, CardMedia, DialogContent } from '@material-ui/core';
import Button from '@material-ui/core/Button';
import React from 'react';
import Dialog from '@material-ui/core/Dialog';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import CloseIcon from '@material-ui/icons/Close';

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
    },
    dialogDiv: {
      display: "flex",
      justifyContent: "center",
    },
    dialogDescription: {
      display: "flex",
      justifyContent: "center",
    },
    dialogMedia: {
      width: 500,
      height: 500,
    },
    divCard: {
      height: 700,
    }

}));
let MarketplaceItem = (props) => {
    const classes = useStyles()
    const [open, setOpen] = React.useState(false);

    const handleClickOpen = () => {
      setOpen(true);
    };

    const handleClose = () => {
      setOpen(false);
    };

    return(

        <Card className={classes.root}>

            <CardContent>
                <CardMedia
                  className={classes.media}
                  title={props.name}
                  image={props.pictureUrl}
                >
                </CardMedia>
                <Typography className={classes.title} color="textSecondary">
                    {props.description}
                </Typography>
                <Typography variant="subtitle1" gutterBottom style={{textAlign: "left"}}>
                    {props.price}.99€
                </Typography>
                <CardActions className={classes.button}>
                  <Button size="medium" onClick={handleClickOpen}> PURCHASE</Button>
                </CardActions>
                  <Dialog
                    maxWidth="xs"
                    open={open}
                    onClose={handleClose}
                  >
                    <IconButton
                      edge="start"
                      color="inherit"
                      onClick={handleClose}
                      aria-label="close"
                    >
                      <CloseIcon />
                    </IconButton>
                    <DialogContent>
                    <div className={classes.dialogDescription}>
                        <CardMedia
                          className={classes.dialogMedia}
                          title={props.name}
                          image={props.pictureUrl}
                        />
                    </div>
                    <div className={classes.dialogDescription}>
                        <Button>
                          Buy selected item {props.price}€
                        </Button>
                    </div>
                  </DialogContent>
                  </Dialog>

            </CardContent>
        </Card>
    )
}

export default MarketplaceItem;
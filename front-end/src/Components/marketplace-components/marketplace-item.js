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
import axios from 'axios';
import { POST_DROP_ITEM_TAKE } from "../../apiCalls/apiUrl.js";
import Snackbar from '@material-ui/core/Snackbar';
import LinearProgress from '@material-ui/core/LinearProgress';

const useStyles = makeStyles((theme) => ({
    /**
     * Creates local styles that can be used with components, still figuring out how to make global components.
     */
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
    const testToken = "9680c79223ab346e8326bc3216fa4ecbd4b43dc0c68993964a93dde5180f98210649dde017d4ac485e4f1282065ef68143dd22603e532c23399cf6207f594284";

    /**
     * React Hooks
     * these constants create a single variable that can be changed dynamically React.useState() can take any params string, boolean, array .. etc,
     * after creation the variable can be changed by using the function provided(setState, showBar, changeMessage..).
     */
    const [openSnackbar, setState] = React.useState(false);
    const [showLinearProgress, showBar] = React.useState(false);
    const [displayMessage, changeMessage] = React.useState("");
    const [disableBuyButton, changeButtonState] = React.useState(true);
    //should defaultly be set to false, and enabled after the user verifies their token.
    const [open, setOpen] = React.useState(false);

    //simplified functions from hooks, can be used in components
    const handleCloseSnackbar = () => {
     setState(false);
    };
    const handleClickOpen = () => {
      setOpen(true);
    };

    const handleClose = () => {
      setOpen(false);
    };

    /**
     * POST_DROP_ITEM_TAKE Api call, sends a payload with the item id and users token, if the user didn't buy anything and the item is available
     * he'll receive an email, if he already bought an item or the item was bought by someone else a warning message appears, saying the item is
     * no longer available
     */
    function handleButton(id) {
      showBar(true);
      let payload = {
        id: props.id,
        token: testToken
      }
      axios.post(POST_DROP_ITEM_TAKE, payload)
        .then(response => {
          changeMessage("You will receive an email regarding the item you selected, congrats");
          setState(true);
          showBar(false);
        })
        .catch(error => {
          console.log(error.response.data.message)
          //the error message is the same, regardless if the item is taken || user already bought an item.
          if(error.response.data.message = "Item was already taken."){
            changeMessage("The item has already been taken");
          }
          else {
            changeMessage("You already bought an item.")
          }
          setState(true);
          showBar(false);
        })
    };

    /**
     * Contains the code for marketplace cards, and the dialogBox that is displayed after clicking the buy button.
     */
    return(

        <Card className={classes.root}>
          <Snackbar
            open={openSnackbar}
            onClose={handleCloseSnackbar}
            message={displayMessage}
            anchorOrigin={{
              vertical: "top",
              horizontal: "center"
            }}
          >
          </Snackbar>
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
                  <Button disabled={ disableBuyButton } size="medium" onClick={handleClickOpen}> PURCHASE</Button>
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
                        <Button onClick = {() => {handleButton(props.id);}}>
                          Buy selected item {props.price}€
                        </Button>
                    </div>
                    {showLinearProgress && <LinearProgress/>}

                  </DialogContent>
                  </Dialog>

            </CardContent>
        </Card>
    )
}

export default MarketplaceItem;
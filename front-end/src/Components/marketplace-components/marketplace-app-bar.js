import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import React from 'react';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import LoginScreen from '../../pages/LoginPage';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    marginLeft: 'auto',
    marginRight: 'auto'

  },
  color: {
    color: "black"
  },
  dialogPaper: {
    minHeight: '80vh',
    maxHeight: '80vh',
},
}));

let MarketplaceAppBar = function() {
  const classes = useStyles();
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };
  return (
    <div className={classes.root}>
      <AppBar position="fixed" className={classes.color} color="white">
        <Toolbar>
          <Typography>Tu bude logo</Typography>
          <Typography variant="h5" className={classes.title}>
            SoleUP
          </Typography>
          <Button
            color="inherit"
            onClick={handleClickOpen}
          >Login</Button>
        </Toolbar>
      </AppBar>
      <Dialog open={open} onClose={handleClose}>
        <DialogContent
          style={{height:'280px', width: "280px"}}
        >
          <LoginScreen></LoginScreen>
        </DialogContent>

      </Dialog>
    </div>
  );
};

export default MarketplaceAppBar;
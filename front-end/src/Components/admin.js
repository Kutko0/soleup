import { makeStyles } from '@material-ui/core/styles';
import { Grid, Table } from '@material-ui/core';
import {TableBody} from '@material-ui/core';
import {TableCell} from '@material-ui/core';
import {TableHead} from '@material-ui/core';
import {TableRow} from '@material-ui/core';
import axios from "axios";
import {useEffect, useState} from "react";
import {GET_ALL_DROP_ITEMS, GET_ALL_DROP_USERS, POST_ADMIN_LOGIN, POST_DROP_ITEM_NEW, POST_DROP_USER_NEW} from "../apiCalls/apiUrl.js";
import {Button} from '@material-ui/core';
import Dialog from '@material-ui/core/Dialog';
import IconButton from '@material-ui/core/IconButton';
import CloseIcon from '@material-ui/icons/Close';
import { DialogContent } from '@material-ui/core';
import TextField from '@material-ui/core/TextField';
import jwt_decode from "jwt-decode";






const useStyles = makeStyles((theme) => ({
  root: {
    overflow: "visible !important"
  },
}));




let Admin = function() {
    const classes = useStyles();
    const [login, setLogin] = useState(false);
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [items, setItems] = useState([]);
    const [users, setAllUsers] = useState([]);
    const [itemDialog, setItemDialog] = useState(false);
    const [userDialog, setUserDialog] = useState(false);
    const [productName, setProductName] = useState("");
    const [productUrl, setProductUrl] = useState("");
    const [productDescription, setProductDescription] = useState("");
    const [productPrice, setProductPrice] = useState(0);
    const [userEmail, setUserEmail] = useState("");
    const [userInstagram, setUserInstagram] = useState("");

    const handleLoginClose = () => {
      setLogin(false);
    }
    const handleCloseItems = () => {
      setItemDialog(false);
    };

    const handleClickOpen = () => {
      setItemDialog(true);
    };

    const handleClickUsers = () => {
      setUserDialog(true);
    };

    const handleCloseUsers = () => {
      setUserDialog (false);
    };

    function adminLogin() {
      let payload = {
        name: username,
        password: password
      }
      console.debug(payload)
      axios.post(POST_ADMIN_LOGIN, payload)
      .then((response) => {
        console.debug(response)

        localStorage.setItem("jwt", response.data.jwtToken)
        //let decoded = jwt_decode(response.data.jwtToken)
        //console.debug(decoded)
        handleLoginClose()

        getAllDropUsers()
        getAllDropItems()

      })
      .catch((error) =>
        console.debug("fuck off")
      )

    }

    function handleButton() {
      let payload = {
        name: productName,
        pictureUrl: productUrl,
        description: productDescription,
        price: productPrice
      }
      axios.post(POST_DROP_ITEM_NEW, payload)
      .then((response) => {
        console.debug(response)
        getAllDropUsers()
        getAllDropItems()
        handleCloseItems()

      })
      .catch((error) => {
        console.debug(error)
      })
    };

    function handleUsers() {
      let payload = {
        email: userEmail,
        instagram: userInstagram
      }
      axios.post(POST_DROP_USER_NEW, payload)
      .then((response) => {
        console.debug(response)
        getAllDropUsers()
        getAllDropItems()
        handleCloseUsers()
      })
      .catch((error) => {
        console.debug(error)
      })
    };

    function getAllDropUsers(){
      axios.get(GET_ALL_DROP_USERS)
      .then((response) => {
        setAllUsers(response.data.item);

      })
      .catch((error) => {
        console.debug(error)
      })
    }
    function getAllDropItems() {
      axios.get(GET_ALL_DROP_ITEMS)
      .then((response) => {
        setItems(response.data.item);

      })
      .catch((error) => {
        console.debug(error)
      })

    }

    useEffect(() => {
      setLogin(true)
      try {
      const jwtToken = jwt_decode(localStorage.getItem("jwt"))
      if(jwtToken.admin_allowed_in == "True"){
        handleLoginClose()
        getAllDropUsers()
        getAllDropItems()
      }
      console.debug("useEffect")
      }
      catch(error){
        console.debug("No valid jwt token")
      }

    }, [])


    return (
        <div>
          <Button variant="contained" color="secondary" onClick={handleClickOpen} >Add product</Button>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Názov produktu</TableCell>
                <TableCell>ID</TableCell>
                <TableCell align="right">Cena produktu</TableCell>
                <TableCell align="right">URL produktu</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {items.map((item) => (
                <TableRow
                  key={item.id}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                <TableCell component="th" scope="row">
                  {item.name}
                </TableCell>
                  <TableCell align="right">{item.id}</TableCell>
                  <TableCell align="right">{item.price}</TableCell>
                  <TableCell align="right">{item.pictureUrl}</TableCell>
                </TableRow>
          ))}
        </TableBody>
          </Table>
          <Button variant="contained" color="secondary" onClick={handleClickUsers}>Add User</Button>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>ID</TableCell>
                <TableCell align="right">Email používateľa</TableCell>
                <TableCell align="right">Instagram používateľa</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {users.map((user) => (
                <TableRow
                  key={user.id}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                <TableCell component="th" scope="row">
                  {user.id}
                </TableCell>
                  <TableCell align="right">{user.email}</TableCell>
                  <TableCell align="right">{user.instagram}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
          <Dialog
            maxWidth="xs"
            open={itemDialog}
            onClose={handleCloseItems}
            className={classes.root}
          >
            <IconButton
              edge="start"
              color="inherit"
              onClick={handleCloseItems}
              aria-label="close"
            >
              <CloseIcon />
            </IconButton>
            <DialogContent>
              <Grid
                container
                spacing={2}
                direction="column"
                alignItems="center"
                justify="center"

              >
                <Grid item xs={12}>
                  <TextField
                    label="Názov produktu"
                    onChange={(e) => {setProductName(e.target.value)}}
                  ></TextField>
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    label="Url produktu"
                    onChange={(e) => {setProductUrl(e.target.value)}}
                  ></TextField>
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    label="Popis"
                    onChange={(e) => {setProductDescription(e.target.value)}}
                  ></TextField>
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    label="Cena"
                    onChange={(e) => {setProductPrice(e.target.value)}}
                  ></TextField>
                </Grid>
                <Grid item xs={12}>
                  <Button color="secondary" variant="contained" onClick={handleButton}>Accept</Button>
                </Grid>
              </Grid>
            </DialogContent>

          </Dialog>

          <Dialog
            maxWidth="sm"
            open={userDialog}
            onClose={handleCloseUsers}
          >
            <IconButton
              edge="start"
              color="inherit"
              onClick={handleCloseUsers}
              aria-label="close"
            >
              <CloseIcon />
            </IconButton>
            <DialogContent>
              <Grid
                container
                spacing={2}
                direction="column"
                alignItems="center"
                justify="center"
              >
                <Grid item xs={12}>
                  <TextField
                    label="Email užívateľa"
                    onChange={(e) => {setUserEmail(e.target.value)}}
                  ></TextField>
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    label="Instagram užívateľa"
                    onChange={(e) => {setUserInstagram(e.target.value)}}
                  ></TextField>
                </Grid>
                <Grid item xs={12}>
                  <Button color="secondary" variant="contained" onClick={handleUsers}>Accept</Button>
                </Grid>
              </Grid>
            </DialogContent>

          </Dialog>
          <Dialog
            fullWidth
            fullScreen
            open={login}
          >
            <DialogContent>
              <Grid
                container
                spacing={2}
                direction="column"
                alignItems="center"
                justify="center"
              >
                <Grid item xs={12}>
                  <TextField
                    label="Login"
                    onChange={(e) => {setUsername(e.target.value)}}
                  ></TextField>
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    label="Password"
                    type="password"
                    onChange={(e) => {setPassword(e.target.value)}}
                  ></TextField>
                </Grid>
                <Grid item xs={12}>
                  <Button color="secondary" variant="contained" onClick={adminLogin}>Accept</Button>
                </Grid>
              </Grid>

            </DialogContent>

          </Dialog>
        </div>
    )

}
export default Admin;
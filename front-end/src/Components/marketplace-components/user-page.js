import GridList from '@material-ui/core/GridList';
import Button from '@material-ui/core/Button';
import GridListTile from '@material-ui/core/GridListTile';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import MarketplaceItem from "../marketplace-components/marketplace-item"
import Box from '@material-ui/core/Box';
import { Container, Grid, ListSubheader } from "@material-ui/core"

const useStyles = makeStyles((theme) => ({
    root: {
      backgroundColor: "grey",
    },
    navigation: {
        marginLeft: "auto",
        marginRight: "auto",
    },
    centerButton: {
      height: "200px"
    },
    buttonStyle: {
      color: "#212121"
    },
    div: {
      margin: "auto",
      width: "1300px",
      padding: "10px",
      heigth: "1300px"

     }

}));

let UserPage = function() {
    const classes = useStyles()
    return (
        <div className={classes.div}>
          <Container className={classes.div}>
            <Typography component="div" style={{ backgroundColor: '#cfe8fc', height: '20vh' }} />
          </Container>
          <Grid>

          </Grid>
        </div>
    )

}
export default UserPage;
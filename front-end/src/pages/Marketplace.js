import { Container} from "@material-ui/core"
import MarketplaceNavigation from "../Components/marketplace-components/marketplace-navigation"
import { makeStyles } from '@material-ui/core/styles';
import  Market  from '../Components/marketplace-components/market-store'
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom';
import Footer from "../Components/marketplace-components/footer";

const useStyles = makeStyles((theme) => ({
    root: {
      backgroundColor: "white",
      alignContent: "center",
    },
    navigation: {
        marginLeft: "auto",
        marginRight: "auto",
    },
    centerButton: {
      height: "100px"
    },
    buttonStyle: {
      color: "#212121"
    },
    footer: {
      position: 'relative', //Here is the trick
      width: "100%",
      bottom: 0,
    }

}));

let MarketplacePage = function(){
    const classes = useStyles()
    return(
    <div className={classes.root}>
      <Router>
        <MarketplaceNavigation className={classes.navigation} />
        <Container>
          <Switch>
            <Route exact path="/">
              <Market/>
            </Route>
          </Switch>
        </Container>
    </Router>
    <div className={classes.footer}>
      <Footer></Footer>
    </div>
    </div>
    )

}

export default MarketplacePage;
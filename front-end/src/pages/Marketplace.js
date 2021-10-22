import { Container} from "@material-ui/core"
import MarketplaceNavigation from "../Components/marketplace-components/marketplace-navigation"
import { makeStyles } from '@material-ui/core/styles';
import  Market  from '../Components/marketplace-components/market-store'
import {BrowserRouter as Router, Route, Switch, Redirect, useLocation} from 'react-router-dom';
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
    const location = useLocation().pathname.slice(1)
    //console.debug(pathname)
    //console.debug("MarketplacePage")
    //console.debug(location);
    return(
    <div className={classes.root}>
      <Router>
        <MarketplaceNavigation className={classes.navigation} />
        <Container>
          <Switch>
            <Route exact path="/*">
              <Market location={location}></Market>
            </Route>
            <Redirect from="*" to="/">
            </Redirect>
          </Switch>
        </Container>
    </Router>
    <div className={classes.footer}>
      <Footer></Footer>
    </div>
    </div>
    )

}

//export default location;
export default MarketplacePage;
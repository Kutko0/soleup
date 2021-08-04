import React from 'react';
import ReactDOM from 'react-dom';
import MarketplaceItem from './Components/marketplace-components/marketplace-item'
import './index.css';
import App from './App';
import LoginScreen from './pages/LoginPage'
import MarketplacePage from './pages/Marketplace'
import MarketplaceAppBar from './Components/marketplace-components/marketplace-app-bar.js'
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'

ReactDOM.render(
  <Router>
    <div>
      <MarketplacePage />
    </div>
  </Router>
  ,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals

import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { EmployeeGrid } from './components/EmployeeGrid';
import { EmployeeRegistration } from './components/EmployeeRegistration';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/employee-grid' component={EmployeeGrid} />
        <Route path='/add-employee' component={EmployeeRegistration} />
      </Layout>
    );
  }
}

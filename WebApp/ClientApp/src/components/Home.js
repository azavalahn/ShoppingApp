import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Welcome to our Employee Management System</h1>

            <p>
                <h3>You will able to add a new employee and to consult employee list</h3>
            </p>
      </div>
    );
  }
}

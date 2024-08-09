// src/App.tsx
import React, { Component } from 'react';
import StaffComponent from './pages/StaffComponent';

interface AppProps {
  title: string;
}

interface AppState {
  counter: number;
}

class App extends Component<AppProps, AppState> {
  constructor(props: AppProps) {
    super(props);
    this.state = {
      counter: 0,
    };
  }

  incrementCounter = () => {
    this.setState({ counter: this.state.counter + 1 });
  };

  render() {
    return (
     <StaffComponent/>
    );
  }
}

export default App;

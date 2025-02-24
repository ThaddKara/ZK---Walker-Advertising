import React, { Component } from 'react';

export class LeadData extends Component {
  static displayName = LeadData.name;

  constructor(props) {
    super(props);

    this.state = { leads: [], loading: true, selected: null };
  }

  componentDidMount() {
    this.fetchLeads();
  }

  renderLeadDetails(lead) {
    return lead !== null ? (
      <div>
        <p>{lead.id}</p>
        <p>{lead.name}</p>
        <p>{lead.phoneNumber}</p>
        <p>{lead.zipCode}</p>
        <p>{lead.emailConsent}</p>
        <p>{lead.emailAddress}</p>
      </div>
    ) : <></>;
  }

  renderLeadTable(leads) {
    return (
      <div>
        <table className='table'>
          <thead>
            <tr>
              <th></th>
              <th>Id</th>
              <th>Name</th>
              <th>Phone Number</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {leads.map(lead =>
              <tr key={lead.id}>
                <td></td>
                <td>{lead.id}</td>
                <td>{lead.name}</td>
                <td>{lead.phoneNumber}</td>
                <td>
                  <button id={lead.id} key={lead.id} className='btn btn-default' onClick={() => {
                    if (lead === this.state.selected) {
                      this.setState({...this.state, selected: null})
                    }
                    else {
                      this.setState({...this.state, selected: lead})
                    }
                  }}>
                    details
                  </button> 
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    );
  }

  render () {
    let contents = this.state.loading ? 
      <p><em>loading leads...</em></p>
      : this.renderLeadTable(this.state.leads);
    return (
      <div>
        <h1>Lead Data</h1>
        {this.renderLeadDetails(this.state.selected)}
        {contents}
      </div>
    )
  }

  async fetchLeads() {
    const response = await fetch('api/Lead');
    const data = await response.json();
    this.setState({ leads: data, loading: false, selected: null });
  }
}

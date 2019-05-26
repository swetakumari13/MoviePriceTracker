class App extends React.Component {

    dataproviders = [{
        key: 'CinemaWorld',
        datasource: '/GetSortedMoviesByPrice/cinemaworld'
    }, {
        key: 'FilmWorld',
        datasource: '/GetSortedMoviesByPrice/filmworld'
    }];

    state = {
        data: this.dataproviders
    }

    refetchdata = () => {
        console.log('refetch data');
        //clean
        this.setState({ data: [] });
        //refetch data
        setTimeout(() => {
            this.setState({ data: this.dataproviders })
        },100);
    }

    render() {
        const h2style = {
            display: 'inline-block'
        };
        return (
            <div className="app">                
                <div className="getdata btn btn-primary" onClick={this.refetchdata}>Reload Data</div>
                {
                    this.state.data.map(function (item, key) {
                        return (
                            <div className="datablock" key={item.key}>
                                <h2 style={h2style}>{item.key}</h2>
                                <MoviesComponent url={item.datasource} />
                            </div>
                    )
                })}
            </div>
        );
    }
}

class MoviesComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: { Movies: [], apiRunning: true }
        };
    }
    componentWillMount() {
        console.log('componentWillMount');
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data, apiRunning: false });
        };
        xhr.send();
    }
    render() {
        return (
            <div className="moviesComponent">
                <table className="table">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Title</th>            
                            <th scope="col">Rating</th>
                            <th scope="col">Metascore</th>
                            <th scope="col">Runtime</th>
                            <th scope="col">Price</th>
                        </tr>
                    </thead>
                    <tbody>{this.state.data.Movies.map(function (item, key) {
                        return (
                            <tr key={item.ID}>
                                <td scope="col">{key+1}</td>
                                <td>{item.Title}</td>
                                <td>{item.DetailedInfo.Rating}</td>
                                <td>{item.DetailedInfo.Metascore}</td>
                                <td>{item.DetailedInfo.Runtime}</td>
                                <td>{item.DetailedInfo.Price}</td>
                            </tr>
                        )
                    })}</tbody>
                </table>
                {this.state.data.apiRunning ? <div className="loading"><i className="fas fa-spinner fa-spin loadingspin"></i></div> : null}
                {!this.state.data.apiRunning && this.state.data.Movies.length == 0 ? <div className="nodata"><i class="fas fa-exclamation-triangle"></i>  Unable to fetch data. Please try again.</div> : null}
            </div>
        );
    }
}

ReactDOM.render(<App />, document.getElementById('content'));
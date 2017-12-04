import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface OperationExampleState {
    operation: Operation;
    loading: boolean;
}

interface Operation {
    name: string;
    summary: string;
    http_method: string;
    operation_id: string;
}

export class FetchOperation extends React.Component<RouteComponentProps<{}>, OperationExampleState> {

    constructor() {
        super();
        this.state = { operation: { summary: "", operation_id: "", name: "", http_method: "" }, loading: true};

        var opPart = "getEnvleope"; // url.split('/')[1];
        var refPageUrl = 'api/RefPage/ReferencePath/' + opPart;
        fetch(refPageUrl)
            .then(response => response.json() as Promise<Operation>)
            .then(data => {
                this.setState({ operation: data, loading: false });
            });

    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchOperation.renderRefPage(this.state.operation, this.props.match.url);

        return <div>
            <h1>Reference page</h1>
            < p > This component demonstrates Rosey getting barked at by Zuzu the pest.</p>
            {contents}
        </div>;
    }

    private static renderRefPage(operation: Operation, op_id: string) {
        return <div className='refpage' >
            <div>Routed OpId HERE </div>
            <div>{op_id}</div>
            <div>Name</div>
            <div>{operation.name}</div>
            <div>Http Method</div>
            <div>{operation.http_method}</div>
            <div>Summary</div>
            <div>{operation.summary}</div>
            <div>Operation Id</div>
            <div>{operation.operation_id}</div>
        </div>;
    }
}



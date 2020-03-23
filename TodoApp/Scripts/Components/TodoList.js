const template = document.createElement('template');

template.innerHTML = `
<li class="list-group-item d-flex justify-content"></li>
`;

class TodoList extends HTMLElement {
    constructor() {
        super();

        this.attachShadow({ mode: 'open' });
        this.shadowRoot.appendChild(template.content.cloneNode(true));
        this.shadowRoot.querySelector('li').innerText = this.getAttribute('title');
    }
}

window.customElements.define('todo-list', TodoList);
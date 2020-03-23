const template = document.createElement('template');

template.innerHTML = `
<link rel="stylesheet" href=""/>
<li class="list-group-item d-flex justify-content-between"></li>
`;

class Todo extends HTMLElement {
    constructor() {
        super();

        this.attachShadow({ mode: 'open' });
        this.shadowRoot.appendChild(template.content.cloneNode(true));
        this.shadowRoot.querySelector('li').innerText = this.getAttribute('title');
    }
}

window.customElements.define('todo-item', Todo);
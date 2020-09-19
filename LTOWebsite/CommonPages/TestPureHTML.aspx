<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestPureHTML.aspx.vb" Inherits="CommonPages_TestPureHTML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>
        heroPlaceholder = document.querySelector('.hero-list');
        const template = document.getElementById('progress-template') as HTMLTemplateElement;
        const fetchingNode = document.importNode(template.content, true);
        heroPlaceholder.replaceWith(fetchingNode);

        function createListWithTemplate(heroes: Hero[]) {
            const ul = document.createElement('ul');
            ul.classList.add('list', 'hero-list');
            const template = document.getElementById('hero-template') as HTMLTemplateElement;
            heroes.forEach((hero: Hero) => {
                const heroCard = document.importNode(template.content, true);
                heroCard.querySelector('.description').textContent = hero.description;
                heroCard.querySelector('.name').textContent = hero.name;
                ul.appendChild(heroCard);
            });
            heroPlaceholder.replaceWith(ul);
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div>

            <template id="progress-template">
        <progress class="hero-list progress is-medium is-info" max="100"></progress>
        </template>
        </div>



        <template id="hero-template">  
            <ul>
            <li>
                <div class="card">
                  <div class="card-content">
                    <div class="content">
                      <div class="name"></div>
                      <div class="description"></div>
                    </div>
                  </div>
                </div>
           
  
              </li> </ul>
        </template>


    </form>
</body>
</html>

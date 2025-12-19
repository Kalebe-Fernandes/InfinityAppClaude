// JavaScript para interceptar navegação do WebView/iframe durante autenticação OAuth
// InfinityApp - Sistema de Apontamento Digital

window.setupAuthWebView = (dotnetHelper) => {
    console.log('InfinityApp: Configurando interceptação de navegação OAuth');
    
    const iframe = document.getElementById('authWebView');
    
    if (!iframe) {
        console.error('InfinityApp: Iframe não encontrado');
        return;
    }

    // Tentar interceptar mudanças de URL do iframe
    // Nota: Devido a restrições de CORS, podemos não conseguir acessar o conteúdo do iframe
    // Em produção, use Chrome Custom Tabs que não tem essa limitação
    
    let lastUrl = '';
    
    const checkUrl = () => {
        try {
            // Tentar acessar URL do iframe (pode falhar por CORS)
            const currentUrl = iframe.contentWindow.location.href;
            
            if (currentUrl !== lastUrl) {
                console.log('InfinityApp: URL mudou:', currentUrl);
                lastUrl = currentUrl;
                
                // Verificar se é callback OAuth
                if (currentUrl.startsWith('infinityapp://')) {
                    console.log('InfinityApp: Callback OAuth detectado!');
                    dotnetHelper.invokeMethodAsync('ProcessarNavegacao', currentUrl);
                }
            }
        } catch (e) {
            // CORS bloqueou acesso - esperado para domínios externos
            // Neste caso, só conseguiremos detectar quando o redirect acontecer
            // e o browser tentar navegar para infinityapp://
        }
    };
    
    // Verificar URL periodicamente
    const intervalId = setInterval(checkUrl, 500);
    
    // Limpar interval quando página for destruída
    window.addEventListener('beforeunload', () => {
        clearInterval(intervalId);
    });
    
    // Listener para tentativa de navegação (alternativa)
    iframe.addEventListener('load', () => {
        console.log('InfinityApp: Iframe carregou nova página');
        checkUrl();
    });
    
    // Capturar tentativas de navegação via message
    window.addEventListener('message', (event) => {
        // Verificar origem por segurança
        if (event.data && typeof event.data === 'string' && event.data.startsWith('infinityapp://')) {
            console.log('InfinityApp: Callback recebido via postMessage');
            dotnetHelper.invokeMethodAsync('ProcessarNavegacao', event.data);
        }
    });
    
    console.log('InfinityApp: Interceptação configurada com sucesso');
};

// Função auxiliar para debug
window.logAuthDebug = (message) => {
    console.log(`[InfinityApp Auth] ${new Date().toISOString()}: ${message}`);
};

// Detectar tentativas de abrir links infinityapp:// no navegador
window.addEventListener('click', (e) => {
    const target = e.target.closest('a');
    if (target && target.href && target.href.startsWith('infinityapp://')) {
        e.preventDefault();
        console.log('InfinityApp: Link infinityapp:// clicado:', target.href);
        
        // Notificar Blazor
        if (window.authDotNetHelper) {
            window.authDotNetHelper.invokeMethodAsync('ProcessarNavegacao', target.href);
        }
    }
});

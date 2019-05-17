
$(document).ready(function () {
    // Basic
    $('#basicTree').jstree({
        'core': {
            'themes': {
                'responsive': false
            }
        },
        'types': {
            'default': {
                'icon': 'zmdi zmdi-folder-star'
            },
            'file': {
                'icon': 'zmdi zmdi-file'
            }
        },
        'plugins': ['types']
    });

    // Checkbox
    $('#checkTree').jstree({
        'core': {
            'themes': {
                'responsive': false
            }
        },
        'types': {
            'default': {
                'icon': 'fa fa-folder'
            },
            'file': {
                'icon': 'fa fa-file'
            }
        },
        'plugins': ['types', 'checkbox']
    });

    // Drag & Drop
    $('#dragTree').jstree({
        'core': {
            'check_callback': true,
            'themes': {
                'responsive': false
            }
        },
        'types': {
            'default': {
                'icon': 'fa fa-folder'
            },
            'file': {
                'icon': 'fa fa-file'
            }
        },
        'plugins': ['types', 'dnd']
    });
});